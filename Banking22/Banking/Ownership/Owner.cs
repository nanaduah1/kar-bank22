namespace Banking22.Banking.Ownership
{
    public abstract class Owner
    {
        public string Name { get; }

        protected Owner(string name)
        {
            Name = name;
        }

    }
}