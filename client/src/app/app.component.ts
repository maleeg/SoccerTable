import { Component } from '@angular/core';
import {TeamsService} from './Service/teams.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  data:any
  constructor(private teamData:TeamsService){}
  ngOnInit(){
    this.teamData.getTeams().subscribe((result) =>{
      this.data=result
    })
  }
}
