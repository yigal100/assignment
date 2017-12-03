import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { IndustriesComponent } from './industries/industries.component';
import { EconomicVariablesComponent } from './economic-variables/economic-variables.component';

const routes: Routes = [
  { path: '', redirectTo: '/dataset/dashboard', pathMatch: 'full' },
  { path: 'dataset/dashboard', component: DashboardComponent },
  { path: 'dataset/industries', component: IndustriesComponent },
  { path: 'dataset/economic_variables', component: EconomicVariablesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
