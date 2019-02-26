import { Component, OnInit } from '@angular/core';
import { SidebarService } from 'src/app/Services/sidebar.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  selectedItem: number = 1;
  isOpen = false;

  constructor(public _sidebarService: SidebarService) { }

  ngOnInit() {
  }

}
