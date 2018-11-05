import { LoginComponent } from "./login.component";
import { ThemeModule } from "../../@theme/theme.module";
import { NgModule } from '@angular/core';

import { NgxEchartsModule } from 'ngx-echarts';


@NgModule({
  imports: [
    ThemeModule,
    NgxEchartsModule,
  ],
  declarations: [
      LoginComponent
  ],
})
export class LoginModule { }
