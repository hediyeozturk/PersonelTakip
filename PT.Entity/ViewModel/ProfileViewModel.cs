﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Entity.ViewModel
{
    public class ProfilePasswordViewModel
    {
        public ProfileViewModel ProfileModel { get; set; } = new ProfileViewModel();
        public PasswordViewModel PasswordModel { get; set; } = new PasswordViewModel();
    }
    public class ProfileViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Ad")]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Şifreniz en az 5 karakter olmalıdır!")]
        [Display(Name = "Eski Şifre")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Şifreniz en az 5 karakter olmalıdır!")]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Compare("NewPassword",ErrorMessage ="Şifreler Uyuşmuyor")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Şifreniz en az 5 karakter olmalıdır!")]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        public string NewPasswordConfirm { get; set; }

    }
    public class PasswordViewModel
    {
        [Display(Name = "Eski Şifre")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Şifreniz En az 5 Karatker Olmalı")]

        public string OldPassword { get; set; }
        [Display(Name = "Yeni Şifre")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Şifreniz En az 5 Karatker Olmalı")]

        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Şifreniz en az 5 karakter olmalıdır")]
        public string NewPasswordConfirm { get; set; }
    }
}
