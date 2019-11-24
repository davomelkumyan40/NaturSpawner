using System;
using GTA;
using GTA.Math;
using GTA.Native;
using System.Windows.Forms;

namespace NaturallySpawner_NoConfig
{
    public class NaturSpawner : Script
    {
        public ModelContainer[] modelList = new ModelContainer[]
        {
            //Millitary
            new ModelContainer(VehicleHash.APC, new Vector3(-2454, 2979, 32), new Vector3(0, 0, -79), 100000),
            new ModelContainer(VehicleHash.HalfTrack, new Vector3(-2455, 2985, 32), new Vector3(0, 0, -79), 100000),
            new ModelContainer(VehicleHash.Brickade, new Vector3(-2452, 2954, 33), new Vector3(0, 0, -35), 100000),
            new ModelContainer(VehicleHash.Frogger, new Vector3(299.8f, -1452.8f, 46), new Vector3(0, 0, 141.7f), VehicleColor.MetallicWhite, VehicleColor.MetallicWhite, 35000),
            new ModelContainer(VehicleHash.Frogger, new Vector3(313.6f, -1464.7f, 46), new Vector3(0, 0, 145), VehicleColor.MetallicWhite, VehicleColor.MetallicWhite, 35000),
            new ModelContainer(VehicleHash.Cargobob, new Vector3(-1859, 2795, 33), new Vector3(0, 0, 150.6f), 70000),
            new ModelContainer(VehicleHash.Savage, new Vector3(-1882, 3100, 33), new Vector3(0, 0, 151), 30000),
            new ModelContainer(VehicleHash.Molotok, new Vector3(-2607, 3307, 33), new Vector3(0, 0, -124), 100000),
            new ModelContainer(VehicleHash.Valkyrie, new Vector3(-1973, 2814, 33), new Vector3(0, 0, -125), 100000),
            new ModelContainer(VehicleHash.Havok, new Vector3(-2100, 2834.9f, 33.39f), new Vector3(0, 0, -11.3f), VehicleColor.MetallicRed, VehicleColor.MetallicRed, 100000),
            new ModelContainer(VehicleHash.Bombushka, new Vector3(-1993.2f, 2850.3f, 33.6f), new Vector3(0, 0, 62), 100000),
            new ModelContainer(VehicleHash.Hydra, new Vector3(-2750, 3287, 33.3f), new Vector3(0, 0, -123.6f), 100000),
            new ModelContainer(VehicleHash.Hunter, new Vector3(-1924, 3127.6f, 34.1f), new Vector3(0, 0, 154.5f), 30000),
            new ModelContainer(VehicleHash.Insurgent, new Vector3(473.1f, -3092, 5.9f), new Vector3(0, 0, -183.9f), 100000),
            new ModelContainer(VehicleHash.Insurgent2, new Vector3(472.9f, -3079, 5.9f), new Vector3(0, 0, -183.7f), 100000),
            new ModelContainer(VehicleHash.NightShark, new Vector3(-270, 2193.8f, 129.2f), new Vector3(0, 0, -125.4f), 100000),
            new ModelContainer(VehicleHash.Kuruma2, new Vector3(464.6f, -3197, 5.8f), new Vector3(0, 0, -95), 100000),
            //City
            new ModelContainer(VehicleHash.Nero, new Vector3(-1033, -490, 36), new Vector3(0, 0, -154), 100000),
            new ModelContainer(VehicleHash.GP1, new Vector3(-448, -458, 32), new Vector3(0, 0, -13), 100000),
            new ModelContainer(VehicleHash.Reaper, new Vector3(-141, -594, 32), new Vector3(0, 0, -115), 100000),
            new ModelContainer(VehicleHash.SultanRS, new Vector3(478, -1893, 25), new Vector3(0, 0, -159), 100000),
            new ModelContainer(VehicleHash.Tempesta, new Vector3(1027, -121, 73), new Vector3(0, 0, -51), 100000),
            new ModelContainer(VehicleHash.XA21, new Vector3(824, 1175, 323), new Vector3(0, 0, 167), 100000),
            new ModelContainer(VehicleHash.Visione, new Vector3(689, 72, 83), new Vector3(0, 0, 61), 100000),
            new ModelContainer(VehicleHash.Elegy, new Vector3(529, -28, 69), new Vector3(0, 0, 35), 100000),
            new ModelContainer(VehicleHash.Seven70, new Vector3(253.5f, 75, 99.1f), new Vector3(0, 0, -25), 100000),
            new ModelContainer(VehicleHash.Nightshade, new Vector3(174, 471, 141), new Vector3(0, 0, -18), 100000),
            new ModelContainer(VehicleHash.Cognoscenti2, new Vector3(-302, -742, 38), new Vector3(0, 0, 163), 100000),
            new ModelContainer(VehicleHash.Police4, new Vector3(146, -695.5f, 32.7f), new Vector3(0, 0, -113.7f), 100000),
            new ModelContainer(VehicleHash.FBI2, new Vector3(141, -744, 32.7f), new Vector3(0, 0, -24), 100000),
            new ModelContainer(VehicleHash.Submersible2, new Vector3(506, -3387, 7), new Vector3(0, 0, 183), 100000),
            new ModelContainer(VehicleHash.Cargobob2, new Vector3(-1145, -2864, 14), new Vector3(0, 0, 155), 100000),
            new ModelContainer(VehicleHash.Supervolito, new Vector3(-1178, -2846, 14), new Vector3(0, 0, 155), 100000),
            new ModelContainer(VehicleHash.XLS2, new Vector3(-978, -2938, 14), new Vector3(0, 0, 124), 100000),
            new ModelContainer(VehicleHash.Khamelion, new Vector3(485, -1082, 28), new Vector3(0, 0, 92), 100000),
            new ModelContainer(VehicleHash.CargoPlane, new Vector3(-1229.4f, -2266, 19.3f), new Vector3(0, 0, 64.7f), 200000),
            new ModelContainer(VehicleHash.AlphaZ1, new Vector3(-1672, -3114, 13.7f), new Vector3(0, 0, -88.3f), 100000),
            new ModelContainer(VehicleHash.Pfister811, new Vector3(-181.3f, 171, 69.6f), new Vector3(0, 0, 179.7f), 100000),
            new ModelContainer(VehicleHash.Comet3, new Vector3(-1890, 122.4f, 80.9f), new Vector3(0, 0, 58.1f), 100000),
            new ModelContainer(VehicleHash.Cyclone, new Vector3(-1997.6f, 296.7f, 91), new Vector3(0, 0, 79.6f), 100000),
            new ModelContainer(VehicleHash.Kuruma, new Vector3(303.6f, -996.1f, 29), new Vector3(0, 0, 90.8f), 100000),
            new ModelContainer(VehicleHash.Contender, new Vector3(603.2f, -3248.3f, 6.3f), new Vector3(0, 0, 5.2f), 100000),
            new ModelContainer(VehicleHash.Riot, new Vector3(-458.3f, 6044, 30.9f), new Vector3(0, 0, -49.3f), 100000),
            new ModelContainer(VehicleHash.Nightblade, new Vector3(3089.5f, 6007.8f, 128.3f), new Vector3(-6, -18, -85), 10000),
            //Prison
            new ModelContainer(VehicleHash.Annihilator, new Vector3(1647.4f, 2614.3f, 45.3f), new Vector3(0, 0, 94.8f), 30000),
            new ModelContainer(VehicleHash.Annihilator, new Vector3(1647.4f, 2596.2f, 45.3f), new Vector3(0, 0, 92.4f), 30000),
    };

        public NaturSpawner()
        {
            this.Interval = 2000;
            Tick += NaturallySpawner_Tick;
            //KeyDown += NaturSpawner_KeyDown;
        }

        private void NaturallySpawner_Tick(object sender, EventArgs e)
        {
            if (!Game.IsLoading)
                try
                {
                    foreach (var model in modelList)
                    {
                        model.CreateOrDelete();
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Something's goin wrong: " + ex.Message, "GTA V Nature Spawner v 1.0.6", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}

