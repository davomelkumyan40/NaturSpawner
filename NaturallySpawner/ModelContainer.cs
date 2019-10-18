using System;
using GTA;
using GTA.Native;
using GTA.Math;

namespace NaturallySpawner
{
    public class ModelContainer
    {
        public bool IsCreated { get; private set; }
        public VehicleHash Hash { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public Vector3 Position { get; private set; }
        public Vector3 Rotation { get; private set; }
        public VehicleColor Primarry { get; private set; }
        public VehicleColor Secondarry { get; private set; }

        public ModelContainer(VehicleHash hash, Vector3 position, Vector3 rotation, VehicleColor primarry, VehicleColor secondarry)
        {
            this.Hash = hash;
            this.Position = position;
            this.Rotation = rotation;
            this.Primarry = primarry;
            this.Secondarry = secondarry;
            this.IsCreated = false;
        }

        public ModelContainer(VehicleHash hash, Vector3 position, Vector3 rotation)
        {
            this.Hash = hash;
            this.Position = position;
            this.Rotation = rotation;
            this.Primarry = this.Secondarry = VehicleColor.DefaultAlloyColor;
            this.IsCreated = false;
        }

        public void Create()
        {
            Vector3 player = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 0, 0));
            if (!IsCreated)
            {
                if (Math.Sqrt((Math.Pow(Math.Pow(player.X, 2) - (2 * player.X * this.Position.X) + Math.Pow(this.Position.X, 2), 2)) +
                   (Math.Pow(Math.Pow(player.Y, 2) - (2 * player.Y * this.Position.Y) + Math.Pow(this.Position.Y, 2), 2)) +
                   (Math.Pow(Math.Pow(player.Z, 2) - (2 * player.Z * this.Position.Z) + Math.Pow(this.Position.Z, 2), 2))) < 100000) // 100000cm = 1000m = 1km
                {
                    OnCreate();
                    if (Debug.IsDebug)
                        UI.Notify("Debug(Created)");

                }
            }
            else if (Math.Sqrt((Math.Pow(Math.Pow(player.X, 2) - (2 * player.X * this.Vehicle.Position.X) + Math.Pow(this.Vehicle.Position.X, 2), 2)) +
                    (Math.Pow(Math.Pow(player.Y, 2) - (2 * player.Y * this.Vehicle.Position.Y) + Math.Pow(this.Vehicle.Position.Y, 2), 2)) +
                    (Math.Pow(Math.Pow(player.Z, 2) - (2 * player.Z * this.Vehicle.Position.Z) + Math.Pow(this.Vehicle.Position.Z, 2), 2))) > 100000)
            {
                Delete();
                if (Debug.IsDebug)
                    UI.Notify("Debug(Deleted)");
            }
        }

        private void Delete()
        {
            this.Vehicle.Delete();
            this.IsCreated = false;

        }

        private void OnCreate()
        {
            this.Vehicle = World.CreateVehicle(new Model(this.Hash), this.Position);
            this.Vehicle.Rotation = this.Rotation;
            if (this.Primarry != VehicleColor.DefaultAlloyColor)
                this.Vehicle.PrimaryColor = this.Primarry;
            if (this.Secondarry != VehicleColor.DefaultAlloyColor)
                this.Vehicle.SecondaryColor = this.Secondarry;
            this.IsCreated = true;
        }
    }
}