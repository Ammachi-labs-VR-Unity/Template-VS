﻿//
//  Outline.cs
//  QuickOutline
//
//  Created by Chris Nolet on 3/30/18.
//  Copyright © 2018 Chris Nolet. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




namespace QuickOutline
{
    [AddComponentMenu("Amrita Skill eLabs/Outline")]
    [DisallowMultipleComponent]
    public class Outline : MonoBehaviour
    {
        public bool userAlternativeOutline = true;

        private static HashSet<Mesh> registeredMeshes = new HashSet<Mesh>();

        public enum Mode
        {
            OutlineAll,
            OutlineVisible,
            OutlineHidden,
            OutlineAndSilhouette,
            SilhouetteOnly
        }

        public Mode OutlineMode
        {
            get { return outlineMode; }
            set
            {
                outlineMode = value;
                needsUpdate = true;
            }
        }

        public Color OutlineColor
        {
            get { return outlineColor; }
            set
            {
                outlineColor = value;
                needsUpdate = true;
            }
        }

        public float OutlineWidth
        {
            get { return outlineWidth; }
            set
            {
                outlineWidth = value;
                needsUpdate = true;
            }
        }

        [Serializable]
        private class ListVector3
        {
            public List<Vector3> data;
        }

        [SerializeField] private Mode outlineMode;

        [Tooltip("Made by Akhila Henry")]
        [SerializeField]
        public bool onlyParentRenderer;

        [SerializeField] private bool doNormals = true;

        [SerializeField] private Color outlineColor = Color.white;

        [SerializeField, Range(0f, 50f)] private float outlineWidth = 2f;

        [Header("Optional")]
        [SerializeField, Tooltip(
             "Precompute enabled: Per-vertex calculations are performed in the editor and serialized with the object. "
             + "Precompute disabled: Per-vertex calculations are performed at runtime in Awake(). This may cause a pause for large meshes.")]
        private bool precomputeOutline;

        [SerializeField, HideInInspector] private List<Mesh> bakeKeys = new List<Mesh>();

        [SerializeField, HideInInspector] private List<ListVector3> bakeValues = new List<ListVector3>();

        private Renderer[] renderers;
        private Material outlineMaskMaterial;
        private Material outlineFillMaterial;

        private bool needsUpdate;

        private bool hasStarted;

        void Awake()
        {
            // Setup();
        }

        // private void Start()
        // {
        //     throw new NotImplementedException();
        // }

        void OnEnable()
        {
            startup();
        }


        void startup()
        {
            if (!hasStarted)
            {
                Setup();
                hasStarted = true;
            }

            foreach (var renderer in renderers)
            {
                // Append outline shaders
                var materials = renderer.sharedMaterials.ToList();

                materials.Add(outlineMaskMaterial);
                if (!userAlternativeOutline)
                    materials.Add(outlineFillMaterial);

                renderer.materials = materials.ToArray();
            }
        }

        private void Setup()
        {
            if (userAlternativeOutline)
            {
                outlineMaskMaterial = Instantiate(Resources.Load<Material>(@"Materials/SimOutliner"));

            }

            if (onlyParentRenderer)
            {
                renderers = new Renderer[1];
                renderers[0] = GetComponent<Renderer>();
            }
            else
            {
                renderers = GetComponentsInChildren<Renderer>();
            }

            if (userAlternativeOutline)
                return;
            outlineMaskMaterial = Instantiate(Resources.Load<Material>(@"Materials/OutlineMask"));
            outlineFillMaterial = Instantiate(Resources.Load<Material>(@"Materials/OutlineFill"));

            outlineMaskMaterial.name = "OutlineMask (Instance)";
            outlineFillMaterial.name = "OutlineFill (Instance)";

            if (doNormals)
                LoadSmoothNormals();

            needsUpdate = true;
        }

        void OnValidate()
        {

            // Update material properties
            needsUpdate = true;

            // Clear cache when baking is disabled or corrupted
            if (!precomputeOutline && bakeKeys.Count != 0 || bakeKeys.Count != bakeValues.Count)
            {
                bakeKeys.Clear();
                bakeValues.Clear();
            }

            // Generate smooth normals when baking is enabled
            if (precomputeOutline && bakeKeys.Count == 0)
            {
                Bake();
            }
        }

        void Update()
        {
            if (userAlternativeOutline)
                return;
            if (needsUpdate)
            {
                needsUpdate = false;

                UpdateMaterialProperties();
            }
        }

        void OnDisable()
        {
            foreach (var renderer in renderers)
            {
                // Remove outline shaders
                var materials = renderer.sharedMaterials.ToList();

                materials.Remove(outlineMaskMaterial);
                if (!userAlternativeOutline)
                    materials.Remove(outlineFillMaterial);

                renderer.materials = materials.ToArray();
            }
        }

        void OnDestroy()
        {
            // Destroy material instances
            Destroy(outlineMaskMaterial);
            Destroy(outlineFillMaterial);
        }

        void Bake()
        {
            // Generate smooth normals for each mesh
            var bakedMeshes = new HashSet<Mesh>();

            foreach (var meshFilter in GetComponentsInChildren<MeshFilter>())
            {
                // Skip duplicates
                if (!bakedMeshes.Add(meshFilter.sharedMesh))
                {
                    continue;
                }

                // Serialize smooth normals
                var smoothNormals = SmoothNormals(meshFilter.sharedMesh);

                bakeKeys.Add(meshFilter.sharedMesh);
                bakeValues.Add(new ListVector3() { data = smoothNormals });
            }
        }

        void LoadSmoothNormals()
        {
            // Retrieve or generate smooth normals
            foreach (var meshFilter in GetComponentsInChildren<MeshFilter>())
            {
                // Skip if smooth normals have already been adopted
                if (!registeredMeshes.Add(meshFilter.sharedMesh))
                {
                    continue;
                }

                // Retrieve or generate smooth normals
                var index = bakeKeys.IndexOf(meshFilter.sharedMesh);
                var smoothNormals = (index >= 0) ? bakeValues[index].data : SmoothNormals(meshFilter.sharedMesh);

                // Store smooth normals in UV3
                meshFilter.sharedMesh.SetUVs(3, smoothNormals);
            }

            // Clear UV3 on skinned mesh renderers
            foreach (var skinnedMeshRenderer in GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                if (registeredMeshes.Add(skinnedMeshRenderer.sharedMesh))
                {
                    skinnedMeshRenderer.sharedMesh.uv4 = new Vector2[skinnedMeshRenderer.sharedMesh.vertexCount];
                }
            }
        }

        List<Vector3> SmoothNormals(Mesh mesh)
        {
            // Group vertices by location
            var groups = mesh.vertices.Select((vertex, index) => new KeyValuePair<Vector3, int>(vertex, index))
                .GroupBy(pair => pair.Key);

            // Copy normals to a new list
            var smoothNormals = new List<Vector3>(mesh.normals);

            // Average normals for grouped vertices
            foreach (var group in groups)
            {
                // Skip single vertices
                if (group.Count() == 1)
                {
                    continue;
                }

                // Calculate the average normal
                var smoothNormal = Vector3.zero;

                foreach (var pair in group)
                {
                    smoothNormal += mesh.normals[pair.Value];
                }

                smoothNormal.Normalize();

                // Assign smooth normal to each vertex
                foreach (var pair in group)
                {
                    smoothNormals[pair.Value] = smoothNormal;
                }
            }

            return smoothNormals;
        }

        void UpdateMaterialProperties()
        {
            if (userAlternativeOutline)
                return;
            // Apply properties according to mode
            outlineFillMaterial.SetColor("_OutlineColor", outlineColor);

            switch (outlineMode)
            {
                case Mode.OutlineAll:
                    outlineMaskMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Always);
                    outlineFillMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Always);
                    outlineFillMaterial.SetFloat("_OutlineWidth", outlineWidth);
                    break;

                case Mode.OutlineVisible:
                    outlineMaskMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Always);
                    outlineFillMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.LessEqual);
                    outlineFillMaterial.SetFloat("_OutlineWidth", outlineWidth);
                    break;

                case Mode.OutlineHidden:
                    outlineMaskMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Always);
                    outlineFillMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Greater);
                    outlineFillMaterial.SetFloat("_OutlineWidth", outlineWidth);
                    break;

                case Mode.OutlineAndSilhouette:
                    outlineMaskMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.LessEqual);
                    outlineFillMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Always);
                    outlineFillMaterial.SetFloat("_OutlineWidth", outlineWidth);
                    break;

                case Mode.SilhouetteOnly:
                    outlineMaskMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.LessEqual);
                    outlineFillMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Greater);
                    outlineFillMaterial.SetFloat("_OutlineWidth", 0);
                    break;
            }
        }
    }
}