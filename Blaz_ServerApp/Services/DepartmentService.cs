using Blaz_ServerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blaz_ServerApp.Services
{
	public class DepartmentService : IService<Department, int>
	{
		private readonly CompanyContext context;
		public DepartmentService(CompanyContext context)
		{
			this.context = context;
		}

		public async Task<Department> CreateAsync(Department entity)
		{
			var result = await context.Departments.AddAsync(entity);
			await context.SaveChangesAsync();
			return result.Entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var result = await context.Departments.FindAsync(id);
			if (result == null) return false;
			context.Departments.Remove(result);
			await context.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<Department>> GetAsync()
		{
			return await context.Departments.ToListAsync();
		}

		public async Task<Department> GetAsync(int id)
		{
			return await context.Departments.FindAsync(id);
		}

		public async Task<Department> UpdateAsync(int id, Department entity)
		{
			var result = await context.Departments.FindAsync(id);
			if (result == null) return null;
			context.Update<Department>(entity);
			await context.SaveChangesAsync();
			return result;
		}
		public async Task<IEnumerable<Department>> GetAsync(Department dept)
		{

			var res = await context.Departments.Where(x => dept.DeptName == null || x.DeptName == dept.DeptName)
				.Select(y => new Department
				{
					DeptName = y.DeptName,
					DeptNo = y.DeptNo,
					Location = y.Location
				}).ToListAsync();
			return res;
		}
	}
}
