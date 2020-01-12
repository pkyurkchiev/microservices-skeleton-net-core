import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-questions-nav-menu',
  templateUrl: './questions-nav-menu.component.html',
  styleUrls: ['./questions-nav-menu.component.scss']
})
export class QuestionsNavMenuComponent implements OnInit {
  @Input() questions: Array<string>;
  @Output() toggle = new EventEmitter<any>();

  constructor() { }

  ngOnInit() { }

  func(questionId) {
    this.toggle.emit({ questionId });
  }
}
