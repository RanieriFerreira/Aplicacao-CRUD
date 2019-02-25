import { TestBed } from '@angular/core/testing';

import { MessagesService } from './messages.service';

describe('MessagesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MessagesService = TestBed.get(MessagesService);
    expect(service).toBeTruthy();
  });

  it('should add a message', () => {
    const service: MessagesService = TestBed.get(MessagesService);
    service.clear();
    service.add("Menssagem", "Status");
    expect(service.messages[0].body).toBeTruthy("Menssagem");
  });

  it('should clear de messages', () => {
    const service: MessagesService = TestBed.get(MessagesService);
    service.add("Menssagem", "Status");
    service.clear();
    expect(service.messages.length).toBe(0);
  });
});
