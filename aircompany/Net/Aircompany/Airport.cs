using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> planes;
        public Airport(IEnumerable<Plane> planes)
        {
            this.planes = planes.ToList();
        }
        public IEnumerable<PassengerPlane> GetPassengersPlanes()
        {
            return planes.Where(t => t.GetType() == typeof(PassengerPlane)).Cast<PassengerPlane>().ToList();
        }
        public IEnumerable<MilitaryPlane> GetMilitaryPlanes()
        {
            return planes.Where(p => p.GetType() == typeof(MilitaryPlane)).Cast<MilitaryPlane>().ToList();
        }
        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes().Aggregate((w, x) => w.GetPassengersCapacity() > x.GetPassengersCapacity() ? w : x);
        }
        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(plane => plane.GetPlaneType() == MilitaryType.Transport).ToList();
        }
        public Airport SortByMaxDistance()
        {
            return new Airport(planes.OrderBy(w => w.GetMaxFlightDistance()));
        }
        public Airport SortByMaxSpeed()
        {
            return new Airport(planes.OrderBy(w => w.GetMaxSpeed()));
        }
        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(planes.OrderBy(w => w.GetMaxLoadCapacity()));
        }
        public IEnumerable<Plane> GetPlanes()
        {
            return planes;
        }
        public override string ToString()
        {
            return "Airport{" + "planes=" + string.Join(", ", planes.Select(x => x.GetModel())) + '}';
        }
    }
}
