import { Component } from '@angular/core';

@Component({
  selector: 'ngx-theme-settings',
  styleUrls: ['./theme-settings.component.scss'],
  template: `
    <h6>CONFIG</h6>
    <div class="settings-row">
      <a *ngFor="let layout of layouts"
         href="#"
         [class.selected]="layout.selected"
         [attr.title]="layout.name"
         (click)="layoutSelect(layout)">
        <i [attr.class]="layout.icon"></i>
      </a>
    </div>
  `,
})
export class ThemeSettingsComponent {

}
