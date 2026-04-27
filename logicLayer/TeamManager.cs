using DataAccessLayer;
using DataDomain;
using System;

namespace LogicLayer
{

    public class TeamManager
    {
        TeamDataAccessor _teamDataAccessor = null;
        
        public List<Team> GetTeamList()
        {
            List<Team> fruits = null;
            try
            {
                if (_teamDataAccessor == null)
                {
                    _teamDataAccessor = new TeamDataAccessor();
                }
                fruits = _teamDataAccessor.GetTeams();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not available", ex);
            }
            return fruits;
        }

        public bool SaveTeam(Team team)
        {
            bool result = false;

            try
            {
                if (_teamDataAccessor == null)
                {
                    _teamDataAccessor = new TeamDataAccessor();
                }

                if (_teamDataAccessor.SaveTeam(team))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Save failed.", ex);
            }

            return result;
        }
    }
}
