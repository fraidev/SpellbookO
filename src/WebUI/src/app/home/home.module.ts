import { NgModule } from '@angular/core';
import { ThemeModule } from '../@theme/theme.module';
import { DashboardModule } from '../pages/dashboard/dashboard.module';
import { MiscellaneousModule } from '../pages/miscellaneous/miscellaneous.module';
import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home.routing';
import { LoginComponent } from './login/login.component';

@NgModule({
  imports: [
    ThemeModule,
    DashboardModule,
    MiscellaneousModule,
    HomeRoutingModule
  ],
  declarations: [
    HomeComponent,
    LoginComponent
  ],
})
export class HomeModule {
}
