import { Component, OnInit, HostBinding  } from '@angular/core';
import { SidebarService } from 'src/app/Services/sidebar.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  constructor(public _sidebarService: SidebarService) { }

  ngOnInit() {
  }

}
