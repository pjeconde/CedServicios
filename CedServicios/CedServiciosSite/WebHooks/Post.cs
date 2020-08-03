using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CedServicios.Site.WebHooks
{
  
        public class Post
        {

            [JsonProperty("ID")]
            public int ID;

            [JsonProperty("post_author")]
            public string PostAuthor;

            [JsonProperty("post_date")]
            public string PostDate;

            [JsonProperty("post_date_gmt")]
            public string PostDateGmt;

            [JsonProperty("post_content")]
            public string PostContent;

            [JsonProperty("post_title")]
            public string PostTitle;

            [JsonProperty("post_excerpt")]
            public string PostExcerpt;

            [JsonProperty("post_status")]
            public string PostStatus;

            [JsonProperty("comment_status")]
            public string CommentStatus;

            [JsonProperty("ping_status")]
            public string PingStatus;

            [JsonProperty("post_password")]
            public string PostPassword;

            [JsonProperty("post_name")]
            public string PostName;

            [JsonProperty("to_ping")]
            public string ToPing;

            [JsonProperty("pinged")]
            public string Pinged;

            [JsonProperty("post_modified")]
            public string PostModified;

            [JsonProperty("post_modified_gmt")]
            public string PostModifiedGmt;

            [JsonProperty("post_content_filtered")]
            public string PostContentFiltered;

            [JsonProperty("post_parent")]
            public int PostParent;

            [JsonProperty("guid")]
            public string Guid;

            [JsonProperty("menu_order")]
            public int MenuOrder;

            [JsonProperty("post_type")]
            public string PostType;

            [JsonProperty("post_mime_type")]
            public string PostMimeType;

            [JsonProperty("comment_count")]
            public string CommentCount;

            [JsonProperty("filter")]
            public string Filter;

        }

        public class PostMeta
        {

            [JsonProperty("_order_key")]
            public List<string> OrderKey;

            [JsonProperty("_customer_user")]
            public List<string> CustomerUser;

            [JsonProperty("_payment_method")]
            public List<string> PaymentMethod;

            [JsonProperty("_payment_method_title")]
            public List<string> PaymentMethodTitle;

            [JsonProperty("_customer_ip_address")]
            public List<string> CustomerIpAddress;

            [JsonProperty("_customer_user_agent")]
            public List<string> CustomerUserAgent;

            [JsonProperty("_created_via")]
            public List<string> CreatedVia;

            [JsonProperty("_cart_hash")]
            public List<string> CartHash;

            [JsonProperty("_billing_first_name")]
            public List<string> BillingFirstName;

            [JsonProperty("_billing_last_name")]
            public List<string> BillingLastName;

            [JsonProperty("_billing_company")]
            public List<string> BillingCompany;

            [JsonProperty("_billing_address_1")]
            public List<string> BillingAddress1;

            [JsonProperty("_billing_city")]
            public List<string> BillingCity;

            [JsonProperty("_billing_state")]
            public List<string> BillingState;

            [JsonProperty("_billing_postcode")]
            public List<string> BillingPostcode;

            [JsonProperty("_billing_country")]
            public List<string> BillingCountry;

            [JsonProperty("_billing_email")]
            public List<string> BillingEmail;

            [JsonProperty("_billing_phone")]
            public List<string> BillingPhone;

            [JsonProperty("_shipping_first_name")]
            public List<string> ShippingFirstName;

            [JsonProperty("_shipping_last_name")]
            public List<string> ShippingLastName;

            [JsonProperty("_shipping_company")]
            public List<string> ShippingCompany;

            [JsonProperty("_shipping_address_1")]
            public List<string> ShippingAddress1;

            [JsonProperty("_shipping_city")]
            public List<string> ShippingCity;

            [JsonProperty("_shipping_state")]
            public List<string> ShippingState;

            [JsonProperty("_shipping_postcode")]
            public List<string> ShippingPostcode;

            [JsonProperty("_shipping_country")]
            public List<string> ShippingCountry;

            [JsonProperty("_order_currency")]
            public List<string> OrderCurrency;

            [JsonProperty("_cart_discount")]
            public List<string> CartDiscount;

            [JsonProperty("_cart_discount_tax")]
            public List<string> CartDiscountTax;

            [JsonProperty("_order_shipping")]
            public List<string> OrderShipping;

            [JsonProperty("_order_shipping_tax")]
            public List<string> OrderShippingTax;

            [JsonProperty("_order_tax")]
            public List<string> OrderTax;

            [JsonProperty("_order_total")]
            public List<string> OrderTotal;

            [JsonProperty("_order_version")]
            public List<string> OrderVersion;

            [JsonProperty("_prices_include_tax")]
            public List<string> PricesIncludeTax;

            [JsonProperty("_billing_address_index")]
            public List<string> BillingAddressIndex;

            [JsonProperty("_shipping_address_index")]
            public List<string> ShippingAddressIndex;

            [JsonProperty("is_vat_exempt")]
            public List<string> IsVatExempt;

            [JsonProperty("_recorded_sales")]
            public List<string> RecordedSales;

            [JsonProperty("_recorded_coupon_usage_counts")]
            public List<string> RecordedCouponUsageCounts;

            [JsonProperty("_order_stock_reduced")]
            public List<string> OrderStockReduced;

            [JsonProperty("_date_paid")]
            public List<string> DatePaid;

            [JsonProperty("_paid_date")]
            public List<string> PaidDate;

            [JsonProperty("_download_permissions_granted")]
            public List<string> DownloadPermissionsGranted;

            [JsonProperty("_edit_lock")]
            public List<string> EditLock;

            [JsonProperty("_edit_last")]
            public List<string> EditLast;

        }

        public class PostBefore
        {

            [JsonProperty("ID")]
            public int ID;

            [JsonProperty("post_author")]
            public string PostAuthor;

            [JsonProperty("post_date")]
            public string PostDate;

            [JsonProperty("post_date_gmt")]
            public string PostDateGmt;

            [JsonProperty("post_content")]
            public string PostContent;

            [JsonProperty("post_title")]
            public string PostTitle;

            [JsonProperty("post_excerpt")]
            public string PostExcerpt;

            [JsonProperty("post_status")]
            public string PostStatus;

            [JsonProperty("comment_status")]
            public string CommentStatus;

            [JsonProperty("ping_status")]
            public string PingStatus;

            [JsonProperty("post_password")]
            public string PostPassword;

            [JsonProperty("post_name")]
            public string PostName;

            [JsonProperty("to_ping")]
            public string ToPing;

            [JsonProperty("pinged")]
            public string Pinged;

            [JsonProperty("post_modified")]
            public string PostModified;

            [JsonProperty("post_modified_gmt")]
            public string PostModifiedGmt;

            [JsonProperty("post_content_filtered")]
            public string PostContentFiltered;

            [JsonProperty("post_parent")]
            public int PostParent;

            [JsonProperty("guid")]
            public string Guid;

            [JsonProperty("menu_order")]
            public int MenuOrder;

            [JsonProperty("post_type")]
            public string PostType;

            [JsonProperty("post_mime_type")]
            public string PostMimeType;

            [JsonProperty("comment_count")]
            public string CommentCount;

            [JsonProperty("filter")]
            public string Filter;

        }

        public class Root
        {

            [JsonProperty("post_id")]
            public int PostId;

            [JsonProperty("post")]
            public Post Post;

            [JsonProperty("post_meta")]
            public PostMeta PostMeta;

            [JsonProperty("post_before")]
            public PostBefore PostBefore;

            [JsonProperty("post_thumbnail")]
            public bool PostThumbnail;

            [JsonProperty("taxonomies")]
            public List<object> Taxonomies;

        }
}