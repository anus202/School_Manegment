using Microsoft.EntityFrameworkCore;
using School_Manegment.Data;
using School_Manegment.Models;

public class GenericService<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericService(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    // 1. Saara Data Get Karne ke liye
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    // 2. ID se Single Record Get Karne ke liye
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    // 3. Aik Record Add Karne ke liye
    public async Task AddAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
     
    }

    // 4. Multiple Records (Bulk) Add Karne ke liye
    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    // 5. ID se Delete Karne ke liye
    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    // 6. Poori Table ka Data Delete Karne ke liye (Bulk Delete)
    public async Task DeleteAllAsync()
    {
        var allRecords = await _dbSet.ToListAsync();
        if (allRecords.Any())
        {
            _dbSet.RemoveRange(allRecords);
            await _context.SaveChangesAsync();
        }
    }
}