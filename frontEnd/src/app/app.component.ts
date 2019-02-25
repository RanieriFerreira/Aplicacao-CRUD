import { Component } from '@angular/core';
import { SidebarService } from './Services/sidebar.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'frontEnd';

  constructor(public _sidebarService: SidebarService){}
}
