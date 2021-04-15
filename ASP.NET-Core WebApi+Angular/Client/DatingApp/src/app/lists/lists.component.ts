import { Component, OnInit } from '@angular/core';
import { Member } from '../_models/member';
import { MembersService } from '../_services/members.service';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {
  members: Partial<Member[]> = [];
  predicate: string = 'liked';

  constructor(private memberService: MembersService) { }

  ngOnInit(): void {
    this.loadLikes(this.predicate);
  }

  loadLikes(predicateTemplate: string) {
    this.predicate = predicateTemplate;
    this.memberService.getLikes(this.predicate).subscribe(response => {
      this.members = response;
    })
  }

  changePredicate() {

  }
}
