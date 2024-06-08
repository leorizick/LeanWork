import { Component, OnInit } from '@angular/core';
import { GithubService } from '../services/github.service';
import { User } from '../../models/user.model';
import { ActivatedRoute, Router } from '@angular/router';
import { UserDetail } from '../../models/userDetail.model';
import { Repository } from '../../models/repository.model';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.css'
})
export class UserDetailComponent implements OnInit {

  user: UserDetail | undefined;
  repos: Repository[] | undefined;

  constructor(
    private readonly githubService: GithubService,
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router
  ) {

  }
  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(res => {
      const username: string | null = res.get('username');
      if (username === null) {
        this.router.navigateByUrl('');
      }
      else {
       this.githubService.getUserDetails(username).subscribe(detail => {
          this.user = detail;
          this.githubService.getUserRepos(username).subscribe(repo => {
            this.repos = repo;
          })
        });
      }
    });

  }

}
