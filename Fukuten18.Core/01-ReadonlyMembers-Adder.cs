namespace Fukuten18.Core
{
    #region Readonly members / 読み取り専用メンバー​

    public struct Adder
    {
        public int A { get; set; }
        public int B { get; set; }

        public readonly override string ToString()
        {
            //A += B; //❌
            return $"A = {A}, B = {B}, A + B = {A + B}";
        }
    }

    #endregion
}
