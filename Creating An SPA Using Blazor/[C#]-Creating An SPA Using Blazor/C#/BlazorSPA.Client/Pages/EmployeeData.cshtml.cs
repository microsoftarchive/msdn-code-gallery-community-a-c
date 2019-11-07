using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorSPA.Shared.Models;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace BlazorSPA.Client.Pages
{
    public class EmployeeDataModel : BlazorComponent
    {
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Parameter]
        protected string paramEmpID { get; set; } = "0";
        [Parameter]
        protected string action { get; set; }

        protected List<Employee> empList = new List<Employee>();
        protected Employee emp = new Employee();
        protected string title { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (action == "fetch")
            {
                await FetchEmployee();
                this.StateHasChanged();
            }
            else if (action == "create")
            {
                title = "Add Employee";
                emp = new Employee();
            }
            else if (paramEmpID != "0")
            {
                if (action == "edit")
                {
                    title = "Edit Employee";
                }
                else if (action == "delete")
                {
                    title = "Delete Employee";
                }

                emp = await Http.GetJsonAsync<Employee>("/api/Employee/Details/" + Convert.ToInt32(paramEmpID));
            }
        }

        protected async Task FetchEmployee()
        {
            title = "Employee Data";
            empList = await Http.GetJsonAsync<List<Employee>>("api/Employee/Index");
        }

        protected async Task CreateEmployee()
        {
            if (emp.EmployeeId != 0)
            {
                await Http.SendJsonAsync(HttpMethod.Put, "api/Employee/Edit", emp);
            }
            else
            {
                await Http.SendJsonAsync(HttpMethod.Post, "/api/Employee/Create", emp);
            }
            UriHelper.NavigateTo("/employee/fetch");
        }

        protected async Task DeleteEmployee()
        {
            await Http.DeleteAsync("api/Employee/Delete/" + Convert.ToInt32(paramEmpID));
            UriHelper.NavigateTo("/employee/fetch");
        }

        protected void Cancel()
        {
            title = "Employee Data";
            UriHelper.NavigateTo("/employee/fetch");
        }
    }
}