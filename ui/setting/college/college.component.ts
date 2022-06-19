import { Component, Inject, Injector, OnInit, Optional, ViewChild,ChangeDetectionStrategy } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { API_BASE_URL, CollegeServiceProxy } from '@shared/service-proxies/service-proxies';
import { FilterSettingsModel, GridComponent, GroupSettingsModel, PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { DataManager, UrlAdaptor   } from '@syncfusion/ej2-data';
import { finalize } from 'rxjs/operators';
import { CreateCollegeDialogComponent } from './create-college/create-college-dialog.component';
import { EditCollegeDialogComponent } from './edit-college/edit-college-dialog.component';
import { L10n, setCulture } from '@syncfusion/ej2-base';
import { LocalizationHelper } from '@shared/localization/localization-helper';

setCulture('ar-SY');
L10n.load(LocalizationHelper.getArabicResources());

@Component({
  selector: 'app-college',
  templateUrl: './college.component.html',
  styleUrls: ['./college.component.scss'],
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CollegeComponent extends AppComponentBase implements OnInit {
  // Grid
  @ViewChild('collegeGrid') public grid: GridComponent;
  public colleges: DataManager;
  public pageSettings: PageSettingsModel;
  public pageSizes: number[] = [6, 20, 100];
  public groupOptions: GroupSettingsModel;
  public filterOption: FilterSettingsModel = { type: 'Menu' };
  private baseUrl: string;
  localizationHelper : LocalizationHelper;
  constructor(injector: Injector,
    private _modalService: NbDialogService,
    private _collegeAppService: CollegeServiceProxy,
    @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    super(injector);
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.pageSettings = {pageSize: 6, pageCount: 10, pageSizes: this.pageSizes};
    this.colleges = new DataManager({
      url: this.baseUrl + '/api/services/app/College/Get',
      adaptor: new UrlAdaptor()
  });
  }
  showCreateDialog() {
    this._modalService.open(
      CreateCollegeDialogComponent
    ).onClose.subscribe((e:any) => {
      console.log("close:: "+e);
      this.refresh();
    });
  }
  showEditDialog(id) {
    this._modalService.open(
      EditCollegeDialogComponent,
      {
        context: {
          id: id,
        },
      }
    ).onClose.subscribe((e:any) => {
      console.log("close:: "+e);
      this.refresh();
    });
  }
  
  delete(data): void {
    abp.message.confirm(
      this.l('DoYouWantToRemoveTheCollege', data.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._collegeAppService
            .delete(data.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }
  refresh() {
    this.grid.refresh();
  }
  clearFilters() {
    this.grid.clearFiltering();
  }
  clearSorts() {
    this.grid.clearSorting();
  }
}
