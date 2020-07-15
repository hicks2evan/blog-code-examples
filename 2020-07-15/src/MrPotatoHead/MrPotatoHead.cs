using System;

namespace _2020_07_15.src.MrPotatoHead
{
    public class MrPotatoHead {
        private IHat hat;
        private IArm[] arms;

        public MrPotatoHead(IHat hat, IArm leftArm, IArm rightArm) {
            this.hat = hat;
            this.arms = new IArm[] {leftArm, rightArm};

            Console.WriteLine("I'm a new potato!");

            hat.Tip();
        }

        public void Wave() {
            arms[1].Wave();
        }

        public double CalculatePotatoNumber(int input) {
            double someSillyNumber = 12345 * (Math.Floor(input + input * (0.9)));
            return someSillyNumber;
        }
    }
}