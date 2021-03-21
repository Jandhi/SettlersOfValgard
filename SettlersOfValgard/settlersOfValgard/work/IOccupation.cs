
using SettlersOfValgardGame.settlersOfValgard.settlers;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard.work
{
    public interface IOccupation : IDescribed
    {
        void Work(SettlersOfValgard game, Settler settler);
    }
}