using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model.Repo
{
    public class ShowingRepository : Repository<Showing>
    {

        public static List<Showing>? GetByDate(DateOnly givenDate)
        {
            Predicate<Showing> matchDate = (showing) =>
            {
                Debug.WriteLine("match found");
                if (showing.ShowingTime.Equals(givenDate)){
                    return true;
                } 
                return false;
            };

            return ShowingRepository.GetInstance().GetAll().FindAll(matchDate);
        }
    }
}
