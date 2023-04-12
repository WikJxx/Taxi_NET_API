namespace Taxi_NET_API.Services.TaxiAssignmentService
{
    public class TaxiAssingmentService : ITaxiAssignmentService
    {
        private readonly DataContext _context;
        private readonly ICombustionTaxiService _combustionTaxiService;
        private readonly IElectricTaxiService _electricTaxiService;
        private readonly ITaxiDriverService _taxiDriverService;

        public TaxiAssingmentService(DataContext context, ICombustionTaxiService combustionTaxiService, IElectricTaxiService electricTaxiService, ITaxiDriverService taxiDriverService)
        {
            _context = context;
            _combustionTaxiService = combustionTaxiService;
            _electricTaxiService = electricTaxiService;
            _taxiDriverService = taxiDriverService;
        }

        public async Task<List<TaxiAssignment>?> GetTaxiAssignments()
        {
            var taxiAssignments = await _context.TaxiAssignments.ToListAsync();

            if (taxiAssignments == null)
            {
                return null;
            }

            return taxiAssignments;

        }

        public async Task<TaxiAssignment?> GetTaxiAssignment(int id)
        {
            var taxiAssignment = await _context.TaxiAssignments.FindAsync(id);

            if (taxiAssignment == null)
            {
                return null;
            }

            return taxiAssignment;
        }

        public async Task<List<TaxiAssignment>?> PutTaxiAssignment(int id, TaxiAssignment request)
        {
            var taxiAssingment = await _context.TaxiAssignments.FindAsync(id);
            if (taxiAssingment == null)
            {
                return null;
            }
            taxiAssingment.TaxiDriverID = request.TaxiDriverID;
            taxiAssingment.TaxiID = request.TaxiID;
            taxiAssingment.IsElectric = request.IsElectric;

            await _context.SaveChangesAsync();
            return await _context.TaxiAssignments.ToListAsync();
        }

        public async Task<List<TaxiAssignment>?> PostTaxiAssignment(TaxiAssignment request)
        {
            var taxiIsManual = false;
            var driverIsManual = false;
            var assingments = await _context.TaxiAssignments.ToListAsync();

            if (request.IsElectric)
            {
                var taxis = await _electricTaxiService.GetElectricTaxis();
                if (taxis == null)
                {
                    return null;
                }
                var taxiExists = false;
                foreach (var taxi in taxis)
                {
                    if (taxi.electricTaxiID == request.TaxiID)
                    {
                        taxiExists = true;
                        taxiIsManual = taxi.IsGearBox;
                    }
                }
                if (!taxiExists)
                {
                    return null;
                }
            }
            else
            {
                var taxis = await _combustionTaxiService.GetCombustionTaxis();
                if (taxis == null)
                {
                    return null;
                }
                var taxiExists = false;
                foreach (var taxi in taxis)
                {
                    if (taxi.CombustionTaxiID == request.TaxiID)
                    {
                        taxiExists = true;
                        taxiIsManual = taxi.IsGearBox;
                    }
                }
                if (!taxiExists)
                {
                    return null;
                }

            }
            var drivers = await _taxiDriverService.GetTaxiDrivers();
            if (drivers == null)
            {
                return null;
            }
            var driverExists = false;
            foreach (var driver in drivers)
            {
                if (driver.TaxiDriverID == request.TaxiDriverID)
                {
                    driverExists = true;
                    driverIsManual = driver.IsManualLicence;
                }
            }
            if (!driverExists)
            {
                return null;
            }
            if (!driverIsManual && taxiIsManual)
            {
                return null;
            }
            foreach (var assingment in assingments)
            {
                if (assingment.TaxiDriverID == request.TaxiDriverID || (assingment.TaxiID == request.TaxiID && assingment.IsElectric == request.IsElectric))
                {
                    return null;
                }
            }
            _context.TaxiAssignments.Add(request);
            await _context.SaveChangesAsync();
            return await _context.TaxiAssignments.ToListAsync();
        }


        public async Task<List<TaxiAssignment>?> DeleteTaxiAssignment(int id)
        {
            var taxiAssignment = await _context.TaxiAssignments.FindAsync(id);
            if (taxiAssignment == null)
            {
                return null;
            }
            _context.TaxiAssignments.Remove(taxiAssignment);
            await _context.SaveChangesAsync();

            return await _context.TaxiAssignments.ToListAsync();

        }



    }
}