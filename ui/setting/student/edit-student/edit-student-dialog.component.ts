import {
    Component,
    Injector,
    OnInit,
    Output,
    EventEmitter
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import {
    StudentServiceProxy, UpdateStudentDto,
    ,









 UniversityDto, UniversityServiceProxy,
 CollegeDto, CollegeServiceProxy,
 MajorDto, MajorServiceProxy,
} from '@shared/service-proxies/service-proxies';
import { NbDialogRef } from '@nebular/theme';
//import endTag

@Component({
    templateUrl: 'edit-student-dialog.component.html',
    styleUrls: ['edit-student-dialog.component.scss']
})
export class EditStudentDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    student: UpdateStudentDto = new UpdateStudentDto();
    id: number;
    









universities: UniversityDto[] = [];
public universityIdFields: Object = { text: 'name', value: 'id' };

colleges: CollegeDto[] = [];
public collegeIdFields: Object = { text: 'name', value: 'id' };

majors: MajorDto[] = [];
public majorIdFields: Object = { text: 'name', value: 'id' };


    @Output() onSave = new EventEmitter<any>();

    constructor(
        injector: Injector,
        public _studentService: StudentServiceProxy,
        









private _universityAppService: UniversityServiceProxy,
private _collegeAppService: CollegeServiceProxy,
private _majorAppService: MajorServiceProxy,

        public dialogRef: NbDialogRef<EditStudentDialogComponent>
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._studentService.getForEdit(this.id).subscribe((result: UpdateStudentDto) => {
            this.student = result;
        });

        









this.initialUniversities();
this.initialColleges();
this.initialMajors();

    }

    save(): void {
        this.saving = true;

        this._studentService
            .update(this.student)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.dialogRef.close();
                this.onSave.emit();
            });
    }

    









initialUniversities(){
    this._universityAppService.getAll()
    .subscribe(result => this.universities = result);
}

initialColleges(){
    this._collegeAppService.getAll()
    .subscribe(result => this.colleges = result);
}

initialMajors(){
    this._majorAppService.getAll()
    .subscribe(result => this.majors = result);
}


}
