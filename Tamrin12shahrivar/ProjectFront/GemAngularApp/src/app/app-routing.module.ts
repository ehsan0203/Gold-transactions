import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GemsComponent } from './gems/gems.component';

const routes: Routes = [
  { path: "gems", component: GemsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
