import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  template: `
  <ngx-home-layout>
    <router-outlet></router-outlet>
  </ngx-home-layout>
`,
})
export class HomeComponent {
}
