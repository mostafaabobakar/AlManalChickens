namespace AlManalChickens.Domain.Enums
{
    public static class ValidationMsg
    {
        //Maximum 30 enum values to guarantee good performance  
        public enum Auth
        {
            /// <summary>
            ///   يجب ان لا تقل كلمة المرور عن 6 رموز
            /// </summary>
            Length = 1,


            /// <summary>
            ///     من فضلك تأكد من البيانات
            /// </summary>
            CheckData = 2,

            /// <summary>
            ///     كلمة المرور غير صحيحة   
            /// </summary>
            PasswordNotFound = 3,

            /// <summary>
            ///     هذا الحساب لم يفعل بعد      
            /// </summary>
            NotActive = 4,

            /// <summary>
            ///     تم اغلاق الحساب من قبل الادمن
            /// </summary>
            Accountblocked = 5,

            /// <summary>
            ///     حدث خطأ ما
            /// </summary>
            SomethingWrong = 6,

            /// <summary>
            ///     من فضلك تأكد من الكود
            /// </summary>
            CodeNotCorrect = 7,

            /// <summary>
            ///     لم يتم العثور على هذا المستخدم
            /// </summary>
            UserNotFound = 8,

            /// <summary>
            ///     كلمة المرور القديمة غير صحيحة
            /// </summary>
            OldPasswordNotCorrect = 9,

            /// <summary>
            ///   تم تغير كلمة المرور بنجاح
            /// </summary>
            Passwordchanged = 10,

            /// <summary>
            ///     تم تسجيل الخروج بنجاح
            /// </summary>
            LogOutSuccessfully = 11,

            /// <summary>
            ///      رقم الهاتف موجود من قبل
            /// </summary>
            PhoneExisting = 12,

            /// <summary>
            ///     البريد الالكترونى موجود من قبل 
            /// </summary>
            EmailExisting = 13,

            /// <summary>
            ///      تم حذف الاشعارات بنجاح
            /// </summary>
            DeleteNotify = 14,

            /// <summary>
            ///      تم التحديث بنجاح
            /// </summary>
            UpdateSuccessfully = 15,

            /// <summary>
            ///      تم الحذف بنجاح
            /// </summary>
            DeleteSuccessfully = 16,

            /// <summary>
            ///      تمت الاضافة بنجاح
            /// </summary>
            AddSuccessfully = 17,

            /// <summary>
            ///      تمت التسجيل بنجاح
            /// </summary>
            RegisterSuccessfully = 18,

            /// <summary>
            ///      تمت الارسال بنجاح
            /// </summary>
            SendSuccessfully = 19,

            /// <summary>
            ///      هذا الحساب قيد المراجعة من الادارة
            /// </summary>
            AdminReview = 20,

            /// <summary>
            ///      لا يوجد كيمة متوفرة لهذا المنتج
            /// </summary>
            ProductQuantityUnavailable = 21,

            /// <summary>
            ///      العربة فارغة
            /// </summary>
            CartEmpty = 22,

            /// <summary>
            ///      تم الغاء الطلب بنجاح
            /// </summary>
            CancelOrder = 23,

            /// <summary>
            ///         ال DeviveID غير موجود 
            /// </summary>
            DeviceId = 24,


            /// <summary>
            ///    هذا الفرع غير موجود 
            /// </summary>
            BranchNotFound = 25,


            /// <summary>
            ///    لا يوجد طلبات ليتم تسويتها 
            /// </summary>

            NoFancailOrders = 26,














        }

        //Maximum 30 enum values to guarantee good performance 
        public enum Required
        {
            /// <summary>
            ///   رقم الهاتف مطلوب
            /// </summary>     
            Phone = 1,

            /// <summary>
            ///   كلمة المرور مطلوبه
            /// </summary>
            Password = 2,

            /// <summary>
            ///  من فضلك تأكد من ادخال deviceType صحيح
            /// </summary>
            DeviceType = 3,

            /// <summary>
            ///     من فضلك تأكد من ادخال deviceId صحيح 
            /// </summary>
            DeviceId = 4,

            /// <summary>
            ///      اسم المستخدم مطلوب
            /// </summary>
            Username = 5,

            /// <summary>
            ///      السجل التجارى مطلوب
            /// </summary>
            CommercialRegistrationNo = 6,

            /// <summary>
            ///      البريد الالكترونى مطلوب
            /// </summary>
            Email = 7,

            /// <summary>
            ///      الكود مطلوب
            /// </summary>
            Code = 8,

            /// <summary>
            ///      UserId مطلوب
            /// </summary>
            UserId = 9,

            /// <summary>
            ///      كلمة المرور القديمه مطلوبه
            /// </summary>
            OldPassword = 10,

            /// <summary>
            ///      كلمة المرور الجديدة مطلوبه
            /// </summary>
            NewPassword = 11,




            /// <summary>
            ///       الرقم الضريبي  مطلوب
            /// </summary>
            TaxNumber = 12,


            /// <summary>
            ///       النشاط مطلوب 
            /// </summary>
            Activity = 13,

            /// <summary>
            ///             المدينة مطلوبة
            /// </summary>
            City = 14,




            /// <summary>
            ///        رقم الحساب مطلوب 
            /// </summary>
            bankNumber = 15,


            /// <summary>
            ///       النشاط مطلوب 
            /// </summary>
            ibanNumber = 16,

            /// <summary>
            ///             المدينة مطلوبة
            /// </summary>
            drivingLicenseImage = 17,

            /// <summary>
            ///             المدينة مطلوبة
            /// </summary>
            IDImage = 18,

            /// <summary>
            ///   لا يمكن عمل طلب مجدول فى نفس اليوم          
            /// </summary>
            ScheduleOrderDate = 19,


            /// <summary>
            ///  هذا الطلب لم يعد متاح        
            /// </summary>
            notavailableorder = 20,

        }


    }
}
