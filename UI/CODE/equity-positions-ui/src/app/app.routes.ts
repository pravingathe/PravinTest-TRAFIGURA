import { RouterModule,Routes } from '@angular/router';
import { TradeEntry } from './trade-entry/trade-entry';
import { PositionsReport } from './positions-report/positions-report';
import { NgModule } from '@angular/core';
export const routes: Routes = [
  { path: 'trade', component: TradeEntry },
  { path: 'report', component: PositionsReport},
  { path: '', redirectTo: 'trade', pathMatch: 'full' }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }