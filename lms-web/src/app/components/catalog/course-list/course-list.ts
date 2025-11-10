import { Component } from '@angular/core';
import { CourseService } from '../../../services/course';

@Component({
  selector: 'app-catalog-course-list',
  templateUrl: './course-list.html',
  styleUrl: './course-list.css',
  standalone: false
})
export class CatalogCourseList {
  courses: any[] = [];

  constructor(private courseService: CourseService) {} 

  ngOnInit() {
    this.courseService.getAll().subscribe((res: any) => {
      this.courses = res;
    });
  }
}
