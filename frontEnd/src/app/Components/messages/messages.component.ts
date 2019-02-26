import { Component, OnInit } from '@angular/core';
import { MessagesService } from 'src/app/Services/messages.service';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {

  constructor(
    public messageService: MessagesService,
    private router: Router
    ) {
    router.events.subscribe((val) => {
      if(val instanceof NavigationEnd)
        this.messageService.clear();
    });
  }

  ngOnInit() {
  }

}
