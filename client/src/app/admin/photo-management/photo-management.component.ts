import { Component, OnInit } from '@angular/core';
import { Photo } from 'src/app/_models/photo';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-photo-management',
  templateUrl: './photo-management.component.html',
  styleUrls: ['./photo-management.component.css']
})
export class PhotoManagementComponent implements OnInit {
  photosForApproval: Photo[] = [];

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
    this.getPhotosForApproval();
  }

  getPhotosForApproval() {
    this.adminService.getPhotosForApproval().subscribe(response => this.photosForApproval = response);
  }

  public approvePhoto(id: number) {
    this.adminService.approvePhoto(id).subscribe(() => {
      this.photosForApproval.splice(this.photosForApproval.findIndex(p => p.id === id), 1);
    });
  }

  public rejectPhoto(id: number) {
    this.adminService.rejectPhoto(id).subscribe(() => {
      this.photosForApproval.splice(this.photosForApproval.findIndex(p => p.id === id), 1);
    });
  }

}
