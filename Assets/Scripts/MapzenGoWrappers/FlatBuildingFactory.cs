﻿using UnityEngine;
using MapzenGo.Models.Settings;
using MapzenGo.Models.Enums;

public class FlatBuildingFactory : MapzenGo.Models.Factories.FlatBuildingFactory
{

    // Use this for initialization
    public override void Start()
    {
        _useTriangulationNet = true;
        MergeMeshes = true;
        Order = 1;

        var bfs = new BuildingFactorySettings();
        bfs.DefaultBuilding = createBuildingSettings(BuildingType.Unknown, 3, 6, "Default");

        bfs.SettingsBuildings = new System.Collections.Generic.List<BuildingSettings> {
            createBuildingSettings(BuildingType.Hospital, 3, 16, "Hospital"),
            createBuildingSettings(BuildingType.Residential, 3, 8, "Residential"),
            createBuildingSettings(BuildingType.Industrial, 4, 8, "Industrial"),
            createBuildingSettings(BuildingType.Commercial, 4, 10, "Commercial"),
            createBuildingSettings(BuildingType.University, 4, 8, "University")
        };

        FactorySettings = bfs;
        base.Start();
    }

    protected BuildingSettings createBuildingSettings(BuildingType type, int min, int max, string material)
    {
        var bs = new BuildingSettings();
        bs.Type = type;
        bs.Material = (Material)Resources.Load(material, typeof(Material));
        bs.MinimumBuildingHeight = min;
        bs.MaximumBuildingHeight = max;
        bs.IsVolumetric = true;
        return bs;
    }
}
