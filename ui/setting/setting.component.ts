import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-index',
  template: `
  <router-outlet></router-outlet>
`
})
export class SettingComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
