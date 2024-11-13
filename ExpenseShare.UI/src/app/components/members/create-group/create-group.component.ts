import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GroupService } from 'src/app/services/group.service';
import { Router } from '@angular/router';
import { GroupDto } from 'src/app/models/group-dto';

@Component({
  selector: 'app-create-group',
  templateUrl: './create-group.component.html',
  styleUrls: ['./create-group.component.css']
})
export class CreateGroupComponent implements OnInit {
  group: GroupDto = {
    name: '',
    description: '',
    memberEmails: []
  };
  members: { email: string }[] = [{ email: '' }];

  constructor(private groupService: GroupService, private router: Router) { }

  ngOnInit(): void { }

  addMember() {
    this.members.push({ email: '' });
  }

  removeMember(index: number) {
    this.members.splice(index, 1);
  }

  onSubmit(form: NgForm) {
    if (form.valid) {
      if(this.members.entries.length < 1)
        alert("A group should have at least 1 member.");
      else if(this.members.entries.length > 10)
        alert("A group cannot have more than 10 members.");
      else {
        this.group.memberEmails = this.members.map(member => member.email);
        this.groupService.addGroup(this.group)
        .subscribe({
          next :(response) => {
            alert(`${this.group.name} group has been created.`);
            this.router.navigate(['/user-details']);
          },
          error :(error) => {
            console.error('Error creating group', error);
            alert('Error creating group');
          }
        });
      }
    }
  }
}
