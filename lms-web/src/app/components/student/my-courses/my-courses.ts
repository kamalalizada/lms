import { Component, OnInit } from '@angular/core';
import { EnrollmentService } from '../../../services/enrollment';

@Component({
  selector: 'app-my-courses',
  templateUrl: './my-courses.html',
  styleUrl: './my-courses.css',
  standalone: false
})
export class MyCourses implements OnInit {
  studentId=1;
  courses:any[]=[];

  constructor(private entrollmentService:EnrollmentService){}

  ngOnInit(): void {
    this.entrollmentService.getByStudentId(this.studentId).subscribe(res => {
      this.courses=res;
    });
  }

}
