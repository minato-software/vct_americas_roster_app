using DataAccessLayer;
using DataDomain;
using System;

namespace LogicLayer
{

    public class TeamManager
    {
        TeamDataAccessor _teamDataAccessor = null;

        public bool DeleteTeam(Team selectedTeam)
        {
            bool result = false;

            try
            {
                if (_teamDataAccessor == null)
                {
                    _teamDataAccessor = new TeamDataAccessor();
                }

                if (_teamDataAccessor.DeleteTeam(selectedTeam))
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

        public List<TeamLogo> GetTeamLogos()
        {
            try
            {
                if (_teamDataAccessor == null)
                {
                    _teamDataAccessor = new TeamDataAccessor();
                }

                return _teamDataAccessor.GetTeamLogos();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't load team logos.", ex);
            }
        }

        public bool SaveTeam(Team team, string originalTeamName = null)
        {
            bool result = false;

            try
            {
                if (_teamDataAccessor == null)
                {
                    _teamDataAccessor = new TeamDataAccessor();
                }

                if (_teamDataAccessor.SaveTeam(team, originalTeamName))
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
