using System;

namespace BikeRental.Core.Domain
{
    public class Bicycle
    {
        protected Bicycle()
        {
        }

        protected Bicycle(string brand, string model, string type)
        {
            SetBrand(brand);
            SetModel(model);
            SetType(type);
        }

        public string Brand { get; protected set; }
        public string Model { get; protected set; }
        public string Type { get; protected set; }

        private void SetBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
                throw new Exception("Please provide valid data.");
            if (Brand == brand)
                return;
            Brand = brand;
        }

        private void SetModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new Exception("Please provide valid data.");
            if (Model == model)
                return;
            Model = model;
        }

        private void SetType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new Exception("Please provide valid data.");
            if (Type == type)
                return;
            Type = type;
        }


        public static Bicycle Create(string brand, string model, string type)
        {
            return new Bicycle(brand, model, type);
        }
    }
}