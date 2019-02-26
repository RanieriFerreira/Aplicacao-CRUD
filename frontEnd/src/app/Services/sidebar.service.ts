import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SidebarService {
  isOpen: boolean = false;

  constructor() { }

  open() {
    this.isOpen = !this.isOpen
  }
}
