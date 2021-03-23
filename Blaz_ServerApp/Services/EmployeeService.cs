using Blaz_ServerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blaz_ServerApp.Services
{
    public class EmployeeService:IService<Employee,int>
    {
		private readonly CompanyContext context;
		public EmployeeService(CompanyContext context)
		{
			this.context = context;
		}

		public async Task<Employee> CreateAsync(Employee entity)
		{
			var result = await context.Employees.AddAsync(entity);
			await context.SaveChangesAsync();
			return result.Entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var result = await context.Employees.FindAsync(id);
			if (result == null) return false;
			context.Employees.Remove(result);
			await context.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<Employee>> GetAsync()
		{
			return await context.Employees.ToListAsync();
		}

		public async Task<Employee> GetAsync(int id)
		{
			return await context.Employees.FindAsync(id);
		}

		public async Task<Employee> UpdateAsync(int id, Employee entity)
		{
			var result = await context.Employees.FindAsync(id);
			if (result == null) return null;
			context.Update<Employee>(entity);
			await context.SaveChangesAsync();
			return result;
		}
		public async Task<IEnumerable<Employee>> GetAsync(Employee emp)
		{

			var res = await context.Employees.Where(x => emp.EmpName == null || x.EmpName == emp.EmpName)
				.Select(y => new Employee
				{
					EmpName=y.EmpName,
					EmpNo=y.EmpNo,
					DeptNo=y.DeptNo,
					Designation=y.Designation,
					Salary=y.Salary,
					DeptNoNavigation=y.DeptNoNavigation
				}).ToListAsync();
			return res;
		}
	}
}
