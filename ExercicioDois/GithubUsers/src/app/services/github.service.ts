import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../../models/user.model';
import { Repository } from '../../models/repository.model';
import { UserDetail } from '../../models/userDetail.model';

@Injectable({
  providedIn: 'root'
})
export class GithubService {
  private baseUrl: string = 'https://api.github.com';

  constructor(private http: HttpClient) {}

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.baseUrl}/users`);
  }

  getUserDetails(username: string): Observable<UserDetail> {
    return this.http.get<UserDetail>(`${this.baseUrl}/users/${username}`);
  }

  getUserRepos(username: string): Observable<Repository[]> {
    return this.http.get<Repository[]>(`${this.baseUrl}/users/${username}/repos`);
  }
}
