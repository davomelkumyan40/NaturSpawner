using System;
using GTA;
using GTA.Math;
using GTA.Native;
using System.Windows.Forms;

namespace NaturallySpawner
{
    public class NaturSpawner : Script
    {
        private ModelContainer[] modelList;

        public NaturSpawner()
        {
            Debug.IsDebug = false;

            modelList = new ModelContainer[]
        {
            //Millitary
            new ModelContainer(VehicleHash.APC, new Vector3(-2454, 2979, 32), new Vector3(0, 0, -79)),
            new ModelContainer(VehicleHash.HalfTrack, new Vector3(-2455, 2985, 32), new Vector3(0, 0, -79)),
            new ModelContainer(VehicleHash.Brickade, new Vector3(-2452, 2954, 33), new Vector3(0, 0, -35)),
            new ModelContainer(VehicleHash.Frogger, new Vector3(300, -1452, 46), new Vector3(0, 0, 143), VehicleColor.MetallicWhite, VehicleColor.MetallicWhite),
            new ModelContainer(VehicleHash.Frogger, new Vector3(300, -1452, 46), new Vector3(0, 0, 143), VehicleColor.MetallicWhite, VehicleColor.MetallicWhite),
            new ModelContainer(VehicleHash.Cargobob, new Vector3(-1859, 2795, 33), new Vector3(0, 0, 153)),
            new ModelContainer(VehicleHash.Lazer, new Vector3(-1882, 3100, 33), new Vector3(0, 0, 151)),
            new ModelContainer(VehicleHash.Molotok, new Vector3(-2607, 3307, 33), new Vector3(0, 0, -124)),
            new ModelContainer(VehicleHash.Valkyrie, new Vector3(-1973, 2814, 33), new Vector3(0, 0, -125)),
            new ModelContainer(VehicleHash.Havok, new Vector3(-2097, 2822, 39), new Vector3(0, 0, -9), VehicleColor.MetallicRed, VehicleColor.MetallicRed),
            new ModelContainer(VehicleHash.Bombushka, new Vector3(-2004, 2856, 33), new Vector3(0, 0, 62)),
            //City
            new ModelContainer(VehicleHash.Nero, new Vector3(-1033, -490, 36), new Vector3(0, 0, -154)),
            new ModelContainer(VehicleHash.GP1, new Vector3(-448, -458, 32), new Vector3(0, 0, -13)),
            new ModelContainer(VehicleHash.Reaper, new Vector3(-141, -594, 32), new Vector3(0, 0, -115)),
            new ModelContainer(VehicleHash.SultanRS, new Vector3(478, -1893, 25), new Vector3(0, 0, -159)),
            new ModelContainer(VehicleHash.Tempesta, new Vector3(1027, -121, 73), new Vector3(0, 0, -51)),
            new ModelContainer(VehicleHash.XA21, new Vector3(824, 1175, 323), new Vector3(0, 0, 167)),
            new ModelContainer(VehicleHash.Visione, new Vector3(689, 72, 83), new Vector3(0, 0, 61)),
            new ModelContainer(VehicleHash.Elegy, new Vector3(529, -28, 69), new Vector3(0, 0, 35)),
            new ModelContainer(VehicleHash.Seven70, new Vector3(253, 75, 99), new Vector3(0, 0, -25)),
            new ModelContainer(VehicleHash.Nightshade, new Vector3(174, 471, 141), new Vector3(0, 0, -18)),
            new ModelContainer(VehicleHash.Cognoscenti2, new Vector3(-302, -742, 38), new Vector3(0, 0, 163)),
            new ModelContainer(VehicleHash.Police4, new Vector3(146, -695.5f, 32.7f), new Vector3(0, 0, -113.7f)),
            new ModelContainer(VehicleHash.FBI2, new Vector3(141, -744, 32.7f), new Vector3(0, 0, -24)),
            new ModelContainer(VehicleHash.Submersible2, new Vector3(506, -3387, 7), new Vector3(0, 0, 183)),
            new ModelContainer(VehicleHash.Cargobob2, new Vector3(-1145, -2864, 14), new Vector3(0, 0, 155)),
            new ModelContainer(VehicleHash.Supervolito, new Vector3(-1178, -2846, 14), new Vector3(0, 0, 155)),
            new ModelContainer(VehicleHash.XLS2, new Vector3(-978, -2938, 14), new Vector3(0, 0, 124)),
            new ModelContainer(VehicleHash.Khamelion, new Vector3(485, -1082, 28), new Vector3(0, 0, 92)),
            new ModelContainer(VehicleHash.CargoPlane, new Vector3(-1229.4f, -2266, 19.3f), new Vector3(0, 0, 64.7f)),
            new ModelContainer(VehicleHash.AlphaZ1, new Vector3(-1672, -3114, 13.7f), new Vector3(0, 0, 129.4f)),
            new ModelContainer(VehicleHash.Pfister811, new Vector3(-181.3f, 171, 69.6f), new Vector3(0, 0, 179.7f)),
            new ModelContainer(VehicleHash.Comet3, new Vector3(-1890, 122.4f, 80.9f), new Vector3(0, 0, 58.1f)),
            new ModelContainer(VehicleHash.Cyclone, new Vector3(-1890, 122.4f, 80.9f), new Vector3(0, 0, 58.1f)),
            new ModelContainer(VehicleHash.Kuruma, new Vector3(303.6f, 996.1f, 29), new Vector3(0, 0, 90.8f)),
    };
            this.Interval = 1000;
            Tick += NaturallySpawner_Tick;
        }


        private void NaturallySpawner_Tick(object sender, EventArgs e)
        {
            if (!Game.IsLoading)
                try
                {
                    foreach (var model in modelList)
                    {
                        model.Create();
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Something's goin wrong: " + ex.Message, "GTA V Nature Spawner v 0.0.2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}
