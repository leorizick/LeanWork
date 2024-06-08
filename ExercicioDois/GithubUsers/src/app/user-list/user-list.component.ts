import { Component, OnInit } from '@angular/core';
import { GithubService } from '../services/github.service';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent implements OnInit{
  
  protected userList:User[] | undefined;
  
  constructor(private readonly githubservice:GithubService){

  }

  ngOnInit(): void {
    this.githubservice.getUsers().subscribe(res => {
      this.userList = res;
    });
  }

}
