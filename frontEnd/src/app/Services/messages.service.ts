import { Injectable } from '@angular/core';
import { Message } from '../Models/message';

@Injectable({
  providedIn: 'root'
})
export class MessagesService {
  messages: Message[] = [];

  add(body: string, status: string) {
    this.messages.push(new Message (body, status));
  }

  clear() {
    this.messages = [];
  }
}
