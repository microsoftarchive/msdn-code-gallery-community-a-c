import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EmployeeComponent } from './components/employee.component';
import { HomeComponent } from './components/home.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'employee', component: EmployeeComponent }
];

export const routing: ModuleWithProviders =
    RouterModule.forRoot(appRoutes);