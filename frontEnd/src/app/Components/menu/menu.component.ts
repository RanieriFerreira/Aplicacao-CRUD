import { Component, OnInit, HostBinding  } from '@angular/core';
import {
  trigger,
  state,
  style,
  animate,
  transition,
} from '@angular/animations';

@Component({
  selector: 'app-menu',
  // animations: [
  //   trigger('openClose', [
  //     state('open', style({
  //       height: '100%',
  //     })),
  //     state('closed', style({
  //       height: '0%',
  //       display: 'none'
  //     })),
  //     transition('open => closed', [
  //       animate('0.5s ease-out')
  //     ]),
  //     transition('closed => open', [
  //       animate('0.5s ease-in')
  //     ]),
  //   ]),
  // ],
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  selectedItem: number = 1;
  isOpen = false;

  constructor() { }

  ngOnInit() {
  }

 
  toggle() {
    this.isOpen = !this.isOpen;
  }

}
