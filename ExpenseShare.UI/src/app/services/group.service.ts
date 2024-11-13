import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GroupDetailsDto } from '../models/group-details-dto';
import { Group } from '../models/group';
import { GroupDto } from '../models/group-dto';
import { GroupMembersDto } from '../models/group-members-dto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GroupService {
  private apiUrl = environment.baseUrl + 'api/group';

  constructor(private http: HttpClient) { }

  addGroup(groupDto: GroupDto): Observable<any> {
    return this.http.post(`${this.apiUrl}`, groupDto);
  }

  getGroups(): Observable<Group[]> {
    return this.http.get<Group[]>(`${this.apiUrl}`);
  }

  getGroupDetails(id: string): Observable<GroupDetailsDto> {
    return this.http.get<GroupDetailsDto>(`${this.apiUrl}/${id}`);
  }

  getGroupMembers(id: string): Observable<GroupMembersDto> {
    return this.http.get<GroupMembersDto>(`${this.apiUrl}/members/${id}`);
  }

  deleteGroup(id: string): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`);
  }
}
