namespace SettlersOfValgard.Model.Settler.Gender
{
    public interface IGendered<out T> where T : Gender
    {
        T Gender { get; }
    }
}