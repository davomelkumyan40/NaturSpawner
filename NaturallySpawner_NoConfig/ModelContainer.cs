using System;
using GTA;
using GTA.Native;
using GTA.Math;

namespace NaturallySpawner_NoConfig
{
    public class ModelContainer
    {
        private bool IsCreated { get; set; }
        public VehicleHash Hash { get; set; }
        private Vehicle Vehicle { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public VehicleColor Primarry { get; set; }
        public VehicleColor Secondarry { get; set; }
        private Vector3 PlayerCoords { get; set; }
        public int Distance { get; set; }

        public ModelContainer(VehicleHash hash, Vector3 position, Vector3 rotation, VehicleColor primarry, VehicleColor secondarry, int distance)
        {
            this.Hash = hash;
            this.Position = position;
            this.Rotation = rotation;
            this.Primarry = primarry;
            this.Secondarry = secondarry;
            this.IsCreated = false;
            this.Distance = distance;
        }

        public ModelContainer(VehicleHash hash, Vector3 position, Vector3 rotation, int distance)
        {
            this.Hash = hash;
            this.Position = position;
            this.Rotation = rotation;
            this.Primarry = this.Secondarry = VehicleColor.DefaultAlloyColor;
            this.IsCreated = false;
            this.Distance = distance;
        }

        public ModelContainer()
        {
            this.Hash = new VehicleHash();
            this.Position = new Vector3(0, 0, 0);
            this.Rotation = new Vector3(0, 0, 0);
            this.Primarry = this.Secondarry = VehicleColor.DefaultAlloyColor;
            this.IsCreated = false;
            this.Distance = 130000;
        }

        public void CreateOrDelete()
        {
            PlayerCoords = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 0, 0));
            if (PlayerCoords != default(Vector3))
            {
                if (!IsCreated)
                {
                    if (Math.Sqrt((Math.Pow(Math.Pow(PlayerCoords.X, 2) - (2 * PlayerCoords.X * this.Position.X) + Math.Pow(this.Position.X, 2), 2)) +
                       (Math.Pow(Math.Pow(PlayerCoords.Y, 2) - (2 * PlayerCoords.Y * this.Position.Y) + Math.Pow(this.Position.Y, 2), 2)) +
                       (Math.Pow(Math.Pow(PlayerCoords.Z, 2) - (2 * PlayerCoords.Z * this.Position.Z) + Math.Pow(this.Position.Z, 2), 2))) < this.Distance) // 100000cm = 1000m = 1km
                        Create();
                }
                else if (Math.Sqrt((Math.Pow(Math.Pow(PlayerCoords.X, 2) - (2 * PlayerCoords.X * this.Vehicle.Position.X) + Math.Pow(this.Vehicle.Position.X, 2), 2)) +
                       (Math.Pow(Math.Pow(PlayerCoords.Y, 2) - (2 * PlayerCoords.Y * this.Vehicle.Position.Y) + Math.Pow(this.Vehicle.Position.Y, 2), 2)) +
                       (Math.Pow(Math.Pow(PlayerCoords.Z, 2) - (2 * PlayerCoords.Z * this.Vehicle.Position.Z) + Math.Pow(this.Vehicle.Position.Z, 2), 2))) > this.Distance)
                    Delete();
            }
        }

        public void Delete()
        {
            this.Vehicle.Delete();
            this.IsCreated = false;
        }

        public void Create()
        {
            this.Vehicle = World.CreateVehicle(new Model(this.Hash), this.Position);
            if (Vehicle != null)
            {
                this.Vehicle.Rotation = this.Rotation;
                if (this.Primarry != VehicleColor.DefaultAlloyColor)
                    this.Vehicle.PrimaryColor = this.Primarry;
                if (this.Secondarry != VehicleColor.DefaultAlloyColor)
                    this.Vehicle.SecondaryColor = this.Secondarry;
                this.IsCreated = true;
            }
        }
    }
}