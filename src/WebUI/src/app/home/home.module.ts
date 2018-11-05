import { NgModule } from '@angular/core';
import { ThemeModule } from '../@theme/theme.module';
import { MiscellaneousModule } from '../pages/miscellaneous/miscellaneous.module';
import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home.routing';
import { LoginModule } from './login/login.module';

const PAGES_COMPONENTS = [
  HomeComponent,
];

@NgModule({
  imports: [
    HomeRoutingModule,
    ThemeModule,
    LoginModule,
    MiscellaneousModule,
  ],
  declarations: [
    PAGES_COMPONENTS
  ],
})
export class HomeModule {
}
