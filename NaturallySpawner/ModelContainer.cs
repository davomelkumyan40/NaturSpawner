using System;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;

namespace NaturallySpawner
{
    public class ModelContainer
    {
        public bool IsFirstTime { get; private set; }
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
            this.IsFirstTime = true;
        }

        public ModelContainer(VehicleHash hash, Vector3 position, Vector3 rotation)
        {
            this.Hash = hash;
            this.Position = position;
            this.Rotation = rotation;
            this.Primarry = this.Secondarry = VehicleColor.DefaultAlloyColor;
            this.IsCreated = false;
            this.IsFirstTime = true;
        }

        public void Create()
        {
            Vector3 player = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 0, 0));
            if (!IsCreated)
            {
                if (IsFirstTime)
                {
                    //let player = {X:140, Y:-735, Z: 33}
                    //VP = SQRT( (player.X^2 - ( 2 * player.X * vehicle.X ) + vehicle.X^2 )^2 + (player.X^2 - ( 2 * player.X * vehicle.X ) + vehicle.X^2 )^2 + (player.X^2 - ( 2 * player.X * vehicle.X ) + vehicle.X^2 )^2
                    if (Math.Sqrt(
                        (Math.Pow(Math.Pow(player.X, 2) - (2 * player.X * this.Position.X) + Math.Pow(this.Position.X, 2), 2)) +
                        (Math.Pow(Math.Pow(player.Y, 2) - (2 * player.Y * this.Position.Y) + Math.Pow(this.Position.Y, 2), 2)) +
                        (Math.Pow(Math.Pow(player.Z, 2) - (2 * player.Z * this.Position.Z) + Math.Pow(this.Position.Z, 2), 2))) < 100000) // 100000cm = 1000m = 1km
                    {
                        IsFirstTime = false;
                        OnCreate();
#if DEBUG
                        UI.Notify("Debug(Created)");
#endif
                    }
                }
                else if (Math.Sqrt(
                        (Math.Pow(Math.Pow(player.X, 2) - (2 * player.X * this.Vehicle.Position.X) + Math.Pow(this.Vehicle.Position.X, 2), 2)) +
                        (Math.Pow(Math.Pow(player.Y, 2) - (2 * player.Y * this.Vehicle.Position.Y) + Math.Pow(this.Vehicle.Position.Y, 2), 2)) +
                        (Math.Pow(Math.Pow(player.Z, 2) - (2 * player.Z * this.Vehicle.Position.Z) + Math.Pow(this.Vehicle.Position.Z, 2), 2))) < 100000)
                {
                    OnCreate();
#if DEBUG
                    UI.Notify("Debug(Created)");
#endif
                }
            }
            else if (Math.Sqrt(
                        (Math.Pow(Math.Pow(player.X, 2) - (2 * player.X * this.Vehicle.Position.X) + Math.Pow(this.Vehicle.Position.X, 2), 2)) +
                        (Math.Pow(Math.Pow(player.Y, 2) - (2 * player.Y * this.Vehicle.Position.Y) + Math.Pow(this.Vehicle.Position.Y, 2), 2)) +
                        (Math.Pow(Math.Pow(player.Z, 2) - (2 * player.Z * this.Vehicle.Position.Z) + Math.Pow(this.Vehicle.Position.Z, 2), 2))) > 100000)
            {
                Delete();
            }
        }

        private void Delete()
        {
            this.Vehicle.Delete();
            this.IsCreated = false;
            this.IsFirstTime = true;
#if DEBUG
            UI.Notify("Debug(Deleted)");
#endif

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